import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import DateTimeFormat = Intl.DateTimeFormat;

@Component({
  selector: 'app-expense-data',
  templateUrl: './expense-data.component.html'
})
export class ExpenseDataComponent {
  public expenses: Expense[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Expense[]>(baseUrl + 'api/Expense/WeatherForecasts').subscribe(result => {
      this.expenses = result;
    }, error => console.error(error));
  }
}

interface Expense {
  id:number;
  date:string;
  amount:number;
  item:string;
  personnel:string;
  title:string;
  description:string;
  labour: string;
  paidfrom:string;
  settledDate:string;
}
