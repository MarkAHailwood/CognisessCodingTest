import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { TestModel } from './TestModel';
import { ApiService } from './Api.Service';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  title = 'Number Guessing Game';
  singleTest = new TestModel();
  blankTest = new TestModel();
  tests: TestModel[];
  randomNo: string = "";
  result: string = "";
  displayNumber: boolean = false;
  displayNumber2: boolean = true;
  displayPrimaryDiv: boolean = true;
  displaySecondaryDiv: boolean = false;
  score: number = 0;
  time: number = 0;
  interval;
  timesTakenArray: number[] = [];
  testsTaken: number = 0;
  testsPassed: number = 0;
  testCounter: string[] = [];
  timerArray: number[] = [];
  constructor(private apiService: ApiService) { }

  beginGame() {
    this.functionNr2();
    this.displayPrimaryDiv = false;
    this.displaySecondaryDiv = true;
    this.refreshTests();
    this.startTimer();
  }

  restartGame() {
    this.displayPrimaryDiv = true;
    this.displaySecondaryDiv = false;
    this.timesTakenArray = [];
    this.testCounter = [];
    this.refreshTests();
  }

  refreshTests() {
    this.singleTest.TestNumber = 0;
    this.apiService.getTest(this.blankTest)
      .subscribe(data => {
        this.singleTest = data;
        this.randomNo = data.randomNumber;
        this.result = data.result;
        this.functionNr1();
      })
  }

  functionNr1() {
    setTimeout(() => {
      this.displayNumber = false;
    }, 3000);
    this.displayNumber = true;
  }

  functionNr2() {
    setTimeout(() => {
      this.displayNumber2 = false;
    }, 60000);
    this.displayNumber2 = true;
    this.singleTest.Complete = true;
  }

  addAnswer() {
    this.pauseTimer();
    this.singleTest.Result = this.result;
    this.singleTest.TimeTaken = this.time;
    this.timesTakenArray.push(this.time);
    this.singleTest.TimesTaken = this.timesTakenArray;
    this.apiService.addTest(this.singleTest)
      .subscribe(data => {
        this.singleTest = data;
        this.randomNo = data.randomNumber;
        this.result = "";
        this.displayNumber = true;
        this.testCounter.push('Attempt ' + String(data.testNumber - 1));
        this.score = data.score;
        this.testsTaken = data.testNumber - 1;
        this.testsPassed = data.score / 10;
        this.functionNr1();
        this.startTimer();     
      })
  }

  startTimer() {
    this.time = 0;
    this.interval = setInterval(() => {
      if (this.time === 0) {
        this.time++;
      } else {
        this.time++;
      }
    }, 1000);
  }

  pauseTimer() {
    clearInterval(this.interval);
  }

  barChartOptions: ChartOptions = {
    responsive: true,
    scales: {
      yAxes: [{
        scaleLabel: {
          display: true,
          labelString: 'Seconds per Answer'
        },
        ticks: {
          min: 0
        }
      }],
     xAxes: [{
        scaleLabel: {
          display: true,
          labelString: 'Answer Number'
        }
      }]
    }
  };

  barChartLabels: Label[] = this.testCounter;
  barChartType: ChartType = 'bar';
  barChartLegend = true;
  barChartPlugins = [];

  barChartData: ChartDataSets[] = [
    {
      data: this.timesTakenArray, label: 'Seconds Taken'
    }
  ];

}
