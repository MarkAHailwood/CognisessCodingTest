import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestModel } from './TestModel';

@Injectable({ providedIn: 'root' })

export class ApiService {

  private _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getTest(testModel: TestModel): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(testModel);
    return this.http.post(this._baseUrl + 'weatherforecast', body, { 'headers': headers })
  }

  addTest(testModel: TestModel): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(testModel);
    return this.http.post(this._baseUrl + 'weatherforecast', body, { 'headers': headers })
  }
}

