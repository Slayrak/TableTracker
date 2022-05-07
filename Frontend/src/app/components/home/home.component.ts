import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public myFormGroup!: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.myFormGroup = new FormGroup({
      people: new FormControl(),
      date: new FormControl(),
      time: new FormControl(),
      restaurant: new FormControl(),
    })
  }

}
