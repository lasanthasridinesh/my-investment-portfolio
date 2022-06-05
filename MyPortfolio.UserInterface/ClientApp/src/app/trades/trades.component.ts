import { Component } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';

@Component({
  selector: 'app-trades-component',
  templateUrl: './trades.component.html'
})

export class TradesComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public events: string[] = [];

  public addEvent(type: string, event: MatDatepickerInputEvent<any,any>) {
    this.events.push(`${type}: ${event.value}`);
  }
}
