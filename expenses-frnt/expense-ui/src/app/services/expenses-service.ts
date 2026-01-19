import { Injectable } from '@angular/core';
import { IExpense } from '../models/expense';

@Injectable({
  providedIn: 'root',
})
export class ExpensesService {
  private expenses = <IExpense[]> [
      {
        id: '1',
        title: 'Groceries',
        amount: 150.75,
        date: new Date('2024-06-01'),
        category: 'Food',
        notes: 'Weekly grocery shopping'
      },
      {
        id: '2',
        title: 'Electricity Bill',
        amount: 60.00,
        date: new Date('2024-06-01'),
        category: 'Utilities'
      },
      {
        id: '3',
        title: 'Gym Membership',
        amount: 45.00,
        date: new Date('2024-06-03'),
        category: 'Health',
        notes: 'Monthly subscription'
      },
      {
        id: '4',
        title: 'Internet Bill',
        amount: 40.00,
        date: new Date('2024-06-03'),
        category: 'Utilities'
      },
      {
        id: '5',
        title: 'Dining Out',
        amount: 80.50,
        date: new Date('2024-06-03'),
        category: 'Entertainment',
        notes: 'Dinner with friends'
      },
      {
        id: '6',
        title: 'Car Fuel',
        amount: 70.00,
        date: new Date('2024-06-06'),
        category: 'Transport'
      }
    ];

  getExpenses(): IExpense[] {
    return this.expenses;
  }

  getExpensesGroupedByDate(): { [date: string]: IExpense[] } {
    return this.expenses.reduce((grouped, expense) => {
      const dateKey = expense.date.toISOString().split('T')[0];
      if (!grouped[dateKey]) {
        grouped[dateKey] = [];
      }
      grouped[dateKey].push(expense);
      return grouped;
    }, {} as { [date: string]: IExpense[] });
  }
}