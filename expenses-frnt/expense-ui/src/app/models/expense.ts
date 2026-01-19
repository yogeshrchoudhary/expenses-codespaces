export interface  IExpense {
  id: string;
  title: string;
  amount: number;
  date: Date;
  category: string;
  notes?: string;
};