﻿
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarRule
	{
		@Expression = 0,                                 // <Expression> ::= <GtOperator>
		@GtOperator_Gt = 1,                              // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 2,                                 // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 3,                              // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 4,                                 // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 5,                           // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 6,                                // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 7,                           // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 8,                                // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 9,                         // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 10,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 11,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 12,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 13,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 14,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 15,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 16,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 17,                             // <OrOperator> ::= <OrOperator> OR <AddExpression>
		@OrOperator_PipePipe = 18,                       // <OrOperator> ::= <OrOperator> '||' <AddExpression>
		@OrOperator = 19,                                // <OrOperator> ::= <AddExpression>
		@AddExpression_Plus = 20,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 21,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 22,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 23,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 24,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 25,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 26,                      // <DivideExpression> ::= <DivideExpression> '/' <UnaryOperator>
		@DivideExpression = 27,                          // <DivideExpression> ::= <UnaryOperator>
		@UnaryOperator_MinusMinus = 28,                  // <UnaryOperator> ::= '--' <Variable>
		@UnaryOperator_PlusPlus = 29,                    // <UnaryOperator> ::= '++' <Variable>
		@UnaryOperator_Minus = 30,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 31,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 32,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 33,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_NOT = 34,                         // <UnaryOperator> ::= NOT <Value>
		@UnaryOperator = 35,                             // <UnaryOperator> ::= <Value>
		@Variable_Identifier = 36,                       // <Variable> ::= Identifier
		@Value_StringDouble = 37,                        // <Value> ::= StringDouble
		@Value_StringSingle = 38,                        // <Value> ::= StringSingle
		@Value_Number = 39,                              // <Value> ::= Number
		@Value_Decimal = 40,                             // <Value> ::= Decimal
		@Value_Boolean = 41,                             // <Value> ::= Boolean
		@Value = 42,                                     // <Value> ::= <Variable>
		@Value2 = 43,                                    // <Value> ::= <Function>
		@Value_LParen_RParen = 44,                       // <Value> ::= '(' <Expression> ')'
		@Program = 45,                                   // <Program> ::= <Statements>
		@Statements = 46,                                // <Statements> ::= <Statement>
		@Statements2 = 47,                               // <Statements> ::= <Statements> <Statement>
		@Statement_NewLine = 48,                         // <Statement> ::= <FlowControl> NewLine
		@Statement_NewLine2 = 49,                        // <Statement> ::= <Assignment> NewLine
		@Statement_NewLine3 = 50,                        // <Statement> ::= <Procedure> NewLine
		@Statement_NewLine4 = 51,                        // <Statement> ::= <Function> NewLine
		@Statement_NewLine5 = 52,                        // <Statement> ::= <Increment> NewLine
		@Statement_NewLine6 = 53,                        // <Statement> ::= <Decrement> NewLine
		@Statement_NewLine7 = 54,                        // <Statement> ::= NewLine
		@Function = 55,                                  // <Function> ::= <UpperFunc>
		@Function2 = 56,                                 // <Function> ::= <LowerFunc>
		@Function3 = 57,                                 // <Function> ::= <TrimFunc>
		@Procedure = 58,                                 // <Procedure> ::= <UnsetProc>
		@Procedure2 = 59,                                // <Procedure> ::= <RejectProc>
		@Procedure3 = 60,                                // <Procedure> ::= <AcceptProc>
		@Procedure4 = 61,                                // <Procedure> ::= <ScopeProc>
		@Procedure5 = 62,                                // <Procedure> ::= <IncludeProc>
		@Procedure6 = 63,                                // <Procedure> ::= <PrintProc>
		@FlowControl = 64,                               // <FlowControl> ::= <IfControl>
		@FlowControl2 = 65,                              // <FlowControl> ::= <WhileControl>
		@IfControl_IF_THEN_NewLine = 66,                 // <IfControl> ::= IF <Expression> THEN NewLine <Statements> <EndIfControl>
		@EndIfControl_END_IF = 67,                       // <EndIfControl> ::= END IF
		@EndIfControl_ELSE_NewLine_END_IF = 68,          // <EndIfControl> ::= ELSE NewLine <Statements> END IF
		@EndIfControl_ELSEIF_THEN_NewLine = 69,          // <EndIfControl> ::= ELSEIF <Expression> THEN NewLine <Statements> <EndIfControl>
		@WhileControl_WHILE_NewLine_END_WHILE = 70,      // <WhileControl> ::= WHILE <Expression> NewLine <Statements> END WHILE
		@DoControl_DO_NewLine_WHILE = 71,                // <DoControl> ::= DO NewLine <Statements> WHILE <Expression>
		@Assignment_VAR_Identifier_Eq = 72,              // <Assignment> ::= VAR Identifier '=' <Expression>
		@Increment_Identifier_PlusPlus = 73,             // <Increment> ::= Identifier '++'
		@Decrement_Identifier_MinusMinus = 74,           // <Decrement> ::= Identifier '--'
		@UnsetProc_UNSET_Identifier = 75,                // <UnsetProc> ::= UNSET Identifier
		@IncludeProc_INCLUDE = 76,                       // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 77,                           // <PrintProc> ::= PRINT <Expression>
		@ScopeProc_SCOPE = 78,                           // <ScopeProc> ::= SCOPE <Expression>
		@RejectProc_REJECT = 79,                         // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 80,                         // <AcceptProc> ::= ACCEPT <Expression>
		@UpperFunc_UPPER_LParen_RParen = 81,             // <UpperFunc> ::= UPPER '(' <Expression> ')'
		@LowerFunc_LOWER_LParen_RParen = 82,             // <LowerFunc> ::= LOWER '(' <Expression> ')'
		@TrimFunc_TRIM_LParen_RParen = 83                // <TrimFunc> ::= TRIM '(' <Expression> ')'
	}
}
