import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestModel } from './TestModel';
import { ApiService } from './Api.Service';

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
  timesTakenArray: Array<number>; 

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }

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
        console.log(data);
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
    this.apiService.addTest(this.singleTest)
      .subscribe(data => {
        console.log(data);
        this.singleTest = data;
        this.preValue = data.preValue;
        this.randomNo = data.randomNumber;
        this.result = "";
        this.displayNumber = true;
        this.functionNr1();
        this.score = data.score;
        this.startTimer();
        this.timesTakenArray = data.TimesTaken;
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
}
