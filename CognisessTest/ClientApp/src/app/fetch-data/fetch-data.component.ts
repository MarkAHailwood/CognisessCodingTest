import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestModel } from './TestModel';
import { ApiService } from './Api.Service';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  title = 'Number Guessing Game';
  singleTest = new TestModel();
  blankTest = new TestModel();
  tests: TestModel[];
  userName: string = "Mark";
  randomNo: string = "";
  result: string = "";
  preValue: string = "";
  displayNumber: boolean = false;
  displayNumber2: boolean = true;
  displayPrimaryDiv: boolean = true;
  displaySecondaryDiv: boolean = false;
  score: number = 0;
  time: number = 0;
  display;
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
    this.refreshTests();
  }

  refreshTests() {
    this.singleTest.TestNumber = 0;
    this.apiService.getTest(this.blankTest)
      .subscribe(data => {
        this.singleTest = data;
        console.log("i refershed");
        this.randomNo = data.randomNumber;
        this.result = data.result;
        this.testCounter.push('Attempt 1');
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
        console.log(this.singleTest.TimesTaken);
        this.singleTest = data;
        this.preValue = data.preValue;
        this.randomNo = data.randomNumber;
        this.result = "";
        this.displayNumber = true;
        this.testCounter.push('Attempt ' + String(data.testNumber));
        this.score = data.score;
        this.testsTaken = data.testNumber;
        this.testsPassed = data.score / 10;
        //this.timerArray = ;
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
      this.display = this.transform(this.time)
    }, 1000);
  }
  transform(value: number): string {
    const minutes: number = Math.floor(value / 60);
    return minutes + ':' + (value - minutes * 60);
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
      data: this.singleTest.TimesTaken, label: 'Seconds Taken'
    }
  ];

}
