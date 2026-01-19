import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header-component/header-component';
import { FooterComponent } from './footer-component/footer-component';
import { ExpenseListComponent } from './expense-list-component/expense-list-component';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, FooterComponent, ExpenseListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('expense-ui');
}
