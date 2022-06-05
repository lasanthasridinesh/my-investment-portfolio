import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';

@Component({
  selector: 'app-trades-component',
  templateUrl: './trades.component.html'
})

export class TradesComponent {

  //public events: string[] = [];
  public tradesArray: Trade[] = [];
  private baseUrl: string = "";
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  public addEvent(type: string, event: MatDatepickerInputEvent<any, any>) {
    //this.events.push(`${type}: ${event.value}`);
    console.log(event.value);
    if (event.value != null) {
      this.http.get<Trade[]>(this.baseUrl + 'trades?tradeDate=' + this.getDateString(event.value))
        .subscribe(result => {
          this.tradesArray = result;
        }, error => console.error(error));
    }

  }

  private getDateString(date: Date) {
    return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
  }
}

interface Trade {
  ticker: string;
  buyOrSell: string;
  quantity: number;
  unitPrice: number;
  totalCost: number
}
