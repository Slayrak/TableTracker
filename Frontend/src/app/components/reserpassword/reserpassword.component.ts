import { Component, OnInit } from '@angular/core';

import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-reserpassword',
  templateUrl: './reserpassword.component.html',
  styleUrls: ['./reserpassword.component.scss']
})
export class ReserpasswordComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  resetpasswordformgroup: FormGroup = new FormGroup( {
    email: new FormControl('', [Validators.required, Validators.email])
  });


}
