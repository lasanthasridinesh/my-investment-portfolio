import { Component, Inject, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GoogleChartInterface, GoogleChartType } from 'ng2-google-charts';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public performanceData: PerformanceItem[] = [];
  private today = new Date();
  public todaysDate = this.today.getFullYear() + '-'
    + (this.today.getMonth() + 1) + '-'
    + this.today.getDate();

  public pieChart: GoogleChartInterface = {
    chartType: GoogleChartType.PieChart,
    firstRowIsData: false,
    options: {
      'title': 'Precentage of each equity in portfolio',
      'is3D': true,
      'width': 600,
      'height': 500
    },
  };

  public columnChart: GoogleChartInterface = {
    chartType: GoogleChartType.ColumnChart,
    firstRowIsData: false,
    options: {
      'title': 'Daily and Inception P&L agains equity',
      'is3D': true,
      'width': 600,
      'height': 500
    },
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private cdr: ChangeDetectorRef) {

    http.get<PerformanceItem[]>(baseUrl + 'trades/performance').subscribe(result => {
      this.performanceData = result;

      var dataTableColumnChart: any[][] = [];
      dataTableColumnChart[0] = ['Ticker', 'Daily P&L', 'Inception P&L'];
      for (var i = 1; i <= result.length; i++) {
        dataTableColumnChart[i] = [];
        dataTableColumnChart[i][0] = result[i - 1].ticker;
        dataTableColumnChart[i][1] = result[i - 1].dailyPandL;
        dataTableColumnChart[i][2] = result[i - 1].inceptionPandL;
      }
      this.columnChart.dataTable = dataTableColumnChart;

      var dataTablePieChart: any[][] = [];
      dataTablePieChart[0] = ['Ticker', 'Quantity'];
      for (var i = 1; i <= result.length; i++) {
        dataTablePieChart[i] = [];
        dataTablePieChart[i][0] = result[i - 1].ticker;
        dataTablePieChart[i][1] = result[i - 1].quantity;
      }
      this.pieChart.dataTable = dataTablePieChart;

      this.cdr.detectChanges();

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
