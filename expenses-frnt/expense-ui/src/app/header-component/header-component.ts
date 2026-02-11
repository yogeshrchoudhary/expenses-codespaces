import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header-component.html',
  styleUrl: './header-component.css',
})
export class HeaderComponent {
  onNewClick() {
    let apiUrl = 'https://psychic-fortnight-rr5ppq554pwhx7jx-5266.app.github.dev/expenses';
    fetch(apiUrl)
      .then((response) => response.json())
      .then((data) => {
        console.log('Expenses fetched from API:', data);
        // You can add logic here to handle the fetched expenses
      })
      .catch((error) => {
        console.error('Error fetching expenses:', error);
      });
  }
}
