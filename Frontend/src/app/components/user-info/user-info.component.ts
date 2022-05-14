import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {

  @Input() fullName!: string;
  @Input() email!: string;
  @Input() dateOfBirth!: string;
  @Input() location!: string;
  @Input() avatar!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
