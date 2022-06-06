import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GoogleChartInterface, GoogleChartType } from 'ng2-google-charts';

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

  public pieChart: GoogleChartInterface = {
    chartType: GoogleChartType.PieChart,
    dataTable: [
      ['Task', 'Hours per Day'],
      ['Work', 11],
      ['Eat', 2],
      ['Commute', 2],
      ['Watch TV', 2],
      ['Sleep', 7]
    ],
    //firstRowIsData: true,
    options: {
      'title': 'Tasks',
      'is3D': true,
      'width': 600,
      'height': 500
    },
  };

  public columnChart: GoogleChartInterface = {
    chartType: GoogleChartType.ColumnChart,
    dataTable: [
      ['Task', 'Hours per Day'],
      ['Work', 11],
      ['Eat', 2],
      ['Commute', 2],
      ['Watch TV', 2],
      ['Sleep', 7]
    ],
    //firstRowIsData: true,
    options: {
      'title': 'Tasks',
      'is3D': true,
      'width': 600,
      'height': 500
    },
  };

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
