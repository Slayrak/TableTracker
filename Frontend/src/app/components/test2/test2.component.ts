import { Component, Input, OnInit } from '@angular/core';
import { Test3 } from '../../models/test3.model';

@Component({
  selector: 'app-test2',
  templateUrl: './test2.component.html',
  styleUrls: ['./test2.component.scss']
})
export class Test2Component implements OnInit {

  @Input() henlo = "cat"

  constructor() { }

  TestArray: Array<string>=["hui", "Spy", "Plane"]

  ngOnInit(): void {
  }

  field1: Test3 = {
    field1: 20,
    field2: "Oleg"
  }

}
