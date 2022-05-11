import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserpasswordComponent } from './reserpassword.component';

describe('ReserpasswordComponent', () => {
  let component: ReserpasswordComponent;
  let fixture: ComponentFixture<ReserpasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReserpasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReserpasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
