import { Component, OnInit } from '@angular/core';
import { IExpense } from '../models/expense';
import { CommonModule} from '@angular/common';
import { ExpensesService } from '../services/expenses-service';

@Component({
  selector: 'app-expense-list',
  imports: [CommonModule],
  templateUrl: './expense-list-component.html',
  styleUrl: './expense-list-component.css',
})
export class ExpenseListComponent implements OnInit {

  protected expenses = <IExpense[]>[];
  protected expensesByDate: { [date: string]: IExpense[] } = {};

  constructor(private expenseService: ExpensesService) {}

  ngOnInit(): void {
    this.expenses = this.expenseService.getExpenses();
    this.expensesByDate = this.expenseService.getExpensesGroupedByDate();
  }
}
