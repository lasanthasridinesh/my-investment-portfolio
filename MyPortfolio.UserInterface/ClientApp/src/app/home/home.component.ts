import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public performanceList: PerformanceItem[] = [];
  private today = new Date();
  public todaysDate = this.today.getFullYear() + '-'
    + (this.today.getMonth() + 1) + '-'
    + this.today.getDate();

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PerformanceItem[]>(baseUrl + 'trades/performance').subscribe(result => {
      this.performanceList = result;
    }, error => console.error(error));
  }
}

interface PerformanceItem {
  ticker: string;
  cost: number;
  quantity: number;
  price: number;
  marketValue: number;
  previousClose: number;
  dailyPandL: number;
  inceptionPandL: number;
}
