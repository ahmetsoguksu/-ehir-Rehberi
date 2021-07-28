import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Value } from '../models/value';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css'],
})
export class ValueComponent implements OnInit {
  constructor(private http: HttpClient) {}

  values: Value[] = [];
  ngOnInit() {
    alert('başladı');
    this.getValues().subscribe((data) => {
      this.values = data;
    });
    alert('devamke');
  }

  getValues() {
    return this.http.get<Value[]>('https://localhost:44305/api/values');
  }
}
