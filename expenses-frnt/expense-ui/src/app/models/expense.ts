export interface  IExpense {
  id: number;
  title: string;
  amount: number;
  date: Date;
  category: string;
  notes?: string;
};

/*
Object received from API >>>>
{
    "id": 1,
    "title": "Groceries",
    "amount": 150.75,
    "date": "2026-02-23T09:37:26.9586848+00:00",
    "category": "Food",
    "notes": "Bought groceries for the week"
}

TODO: Convert this object to match the IExpense interface, ensuring that the 'id' is a string and the 'date' is a Date object.
*/