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
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.scss']
})
export class FaqComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  whoWeAreOpenState = false;
  doesWeHaveAnOpenState = false;
  freeOpenState = false;
  bookOpenState = false;
  needOpenState = false;

  emailForm: FormGroup = new FormGroup( {
    email: new FormControl('', [Validators.required, Validators.email]),
    question: new FormControl('', Validators.required)
  });

  sendEmail(emailFormValue) {
    
  }
  
}
