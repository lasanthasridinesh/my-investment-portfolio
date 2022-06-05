import { Component } from '@angular/core';

@Component({
  selector: 'app-trades-component',
  templateUrl: './trades.component.html'
})
export class TradesComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
