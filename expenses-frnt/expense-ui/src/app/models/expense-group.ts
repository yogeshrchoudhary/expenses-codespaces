import { IExpense } from "./expense";

export interface IExpenseGroup {
    date: Date;
    expenses: IExpense[];
    total: number;
}
