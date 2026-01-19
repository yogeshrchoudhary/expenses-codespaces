import { Component, OnInit } from '@angular/core';
import { CommonModule, KeyValue} from '@angular/common';
import { ExpensesService } from '../services/expenses-service';
import { IExpenseGroup } from '../models/expense-group';

@Component({
  selector: 'app-expense-list',
  imports: [CommonModule],
  templateUrl: './expense-list-component.html',
  styleUrl: './expense-list-component.css',
})
export class ExpenseListComponent implements OnInit {

  protected groupedExpensesWithTotals: { [date: string]: IExpenseGroup } = {};

  constructor(private expenseService: ExpensesService) {}

  ngOnInit(): void {
    this.groupedExpensesWithTotals = this.expenseService.getExpensesGroupedByDateWithTotals();
  }

  reverse = (keyA: KeyValue<string, IExpenseGroup>, keyB: KeyValue<string, IExpenseGroup>): number => {
    return keyA.key < keyB.key ? 1 : -1;
  }
}
