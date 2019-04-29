﻿using Calculator.Service.DTOs;
using CalculatorChallenge.CalculationService;
using CalculatorChallenge.Commands;
using CalculatorChallenge.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorChallenge.ViewModels
{
    public class CalculatorViewModel : 
        ViewModelBase
    {
        #region Members

        private readonly CalculationModel _calculation;
        public CalculationServiceClient calculationService;
    
        private bool _newDisplayRequired;

        #endregion

        #region CTor

        public CalculatorViewModel()
        {
            _calculation = new CalculationModel();
            _display = "0";
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            Operation = string.Empty;
            _lastOperation = string.Empty;
            _fullExpression = string.Empty;
            calculationService = new CalculationServiceClient();
            CalculationHistory = new Dictionary<Guid, string>();
            LoadCalculationHistory(calculationService);
        }

        #endregion

        #region Properties

        public string FirstOperand
        {
            get => _calculation.FirstOperand;
            set => _calculation.FirstOperand = value;
        }

        public string SecondOperand
        {
            get => _calculation.SecondOperand;
            set => _calculation.SecondOperand = value;
        }

        public string Operation
        {
            get => _calculation.Operation;
            set => _calculation.Operation = value;
        }

        private string _lastOperation;
        public string LastOperation
        {
            get => _lastOperation;
            set => Set(ref _lastOperation, value);
        }

        public string Result
        {
            get => _calculation.Result;
            set => Set(ref _display, value);
        }

        private string _display;
        public string Display
        {
            get => _display;
            set => Set(ref _display, value);
        }

        private string _fullExpression;
        public string FullExpression
        {
            get => _fullExpression;
            set => Set(ref _fullExpression, value);
        }

        public Dictionary<Guid, string> _calculationHistory;
        public Dictionary<Guid,string> CalculationHistory
        {
            get => _calculationHistory;
            set => Set(ref _calculationHistory, value);
        }       

        #endregion

        #region Methods

        //Write the full exception to the eventlog
        private static void LogExceptionInformation(Exception ex)
        {
            //TODO:
        }

        private void LoadCalculationHistory(CalculationServiceClient calculationService)
        {
            CalculationHistory?.Clear();
            calculationService.GetAllData()
                              .ToList()
                              .ForEach(x=>
                              {
                                  var value = $"{x.FirstOperand}{x.Operation}{x.SecondOperand}={x.Result}";
                                  CalculationHistory.Add(x.CalculatorId, value);
                              });
        }

        private void LoadCalculationHistory(CalculatorOperation x)
        {
            var value = $"{x.FirstOperand}{x.Operation}{x.SecondOperand}={x.Result}";
            CalculationHistory.Add(x.CalculatorId, value);
        }

        #endregion

        #region Callbacks

        //deals with button inputs and sorts out the display accordingly
        public void OnDigitButtonPress(string button)
        {
            switch (button)
            {
                case "C":
                    Display = "0";
                    FirstOperand = string.Empty;
                    SecondOperand = string.Empty;
                    Operation = string.Empty;
                    LastOperation = string.Empty;
                    FullExpression = string.Empty;
                    break;
                case "Del":
                    if (_display.Length > 1)
                        Display = _display.Substring(0, _display.Length - 1);
                    else Display = "0";
                    break;
                case "+/-":
                    if (_display.Contains("-") || _display == "0")
                    {
                        Display = _display.Remove(_display.IndexOf("-"), 1);
                    }
                    else Display = "-" + _display;
                    break;
                case ".":
                    if (_newDisplayRequired)
                    {
                        Display = "0.";
                    }
                    else
                    {
                        if (!_display.Contains("."))
                        {
                            Display = _display + ".";
                        }
                    }
                    break;
                default:
                    if (_display == "0" || _newDisplayRequired)
                        Display = button;
                    else
                        Display = _display + button;
                    break;
            }
            _newDisplayRequired = false;
        }

        //for operations with 2 operands
        public void OnOperationButtonPress(string operation)
        {
            try
            {
                if (FirstOperand == string.Empty || LastOperation == "=")
                {
                    FirstOperand = _display;
                    LastOperation = operation;
                }
                else
                {
                    SecondOperand = _display;
                    Operation = _lastOperation;
                    var calculationResultRequest = new CalculateResultRequest
                    {
                        FirstOperand = FirstOperand,
                        SecondOperand = SecondOperand, 
                        Operator = Operation
                    };
                    var calculationServiceResult = calculationService.CalculateResult(calculationResultRequest);
                    LoadCalculationHistory(calculationServiceResult);

                    FullExpression = Math.Round(Convert.ToDouble(FirstOperand), 10) + " " + Operation + " "
                                    + Math.Round(Convert.ToDouble(SecondOperand), 10) + " = "
                                    + Math.Round(Convert.ToDouble(calculationServiceResult.Result), 10);

                    LastOperation = operation;
                    Display = Result;
                    FirstOperand = _display;
                }
                _newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
                LogExceptionInformation(ex);
            }
        }

       

        //for sin,cos,tan
        public void OnSingularOperationButtonPress(string operation)
        {
            try
            {
                FirstOperand = Display;
                Operation = operation;
                var calculationResultRequest = new CalculateResultRequest
                {
                    FirstOperand = FirstOperand,
                    Operator = Operation
                };
                var calculationServiceResult = calculationService.CalculateResult(calculationResultRequest);
                LoadCalculationHistory(calculationServiceResult);

                FullExpression = Operation + "(" + Math.Round(Convert.ToDouble(FirstOperand), 10) + ") = "
                    + Math.Round(Convert.ToDouble(calculationServiceResult.Result), 10);

                LastOperation = "=";
                Display = Result;
                FirstOperand = _display;
                _newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
                LogExceptionInformation(ex);
            }
        }
         private void OnOperationUndoButtonPress(string obj)
        {
            var id = CalculationHistory.Last().Key;
            var result = calculationService.GetDataFromGuid(id);
            FirstOperand = result.FirstOperand;
            SecondOperand = result.SecondOperand;
            Operation = result.Operation;
            Display = Result = result.Result;

            if (string.IsNullOrEmpty(result.SecondOperand))
            {
                FullExpression = Operation + "(" + Math.Round(Convert.ToDouble(FirstOperand), 10) + ") = "
                   + Math.Round(Convert.ToDouble(result.Result), 10);
            }
            else
            {
                FullExpression = Math.Round(Convert.ToDouble(FirstOperand), 10) + " " + Operation + " "
                                        + Math.Round(Convert.ToDouble(SecondOperand), 10) + " = "
                                        + Math.Round(Convert.ToDouble(result.Result), 10);
            }

            CalculationHistory.Remove(id);
        }

        #endregion

        #region Commands

        private DelegateCommand<string> _operationButtonPressCommand;
        public ICommand OperationButtonPressCommand => _operationButtonPressCommand ?? (_operationButtonPressCommand = new DelegateCommand<string>(OnOperationButtonPress));

        private DelegateCommand<string> _singularOperationButtonPressCommand;
        public ICommand SingularOperationButtonPressCommand => _singularOperationButtonPressCommand ?? (_singularOperationButtonPressCommand = new DelegateCommand<string>(OnSingularOperationButtonPress));

        private DelegateCommand<string> _digitButtonPressCommand;
        public ICommand DigitButtonPressCommand => _digitButtonPressCommand ?? (_digitButtonPressCommand = new DelegateCommand<string>(OnDigitButtonPress));

        private DelegateCommand<string> _operationUndoButtonPressCommand;
        public ICommand OperationUndoButtonPressCommand => _operationUndoButtonPressCommand ?? (_operationUndoButtonPressCommand = new DelegateCommand<string>(OnOperationUndoButtonPress));

       

        #endregion
    }
}
