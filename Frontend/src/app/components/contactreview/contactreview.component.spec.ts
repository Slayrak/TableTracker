import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactreviewComponent } from './contactreview.component';

describe('ContactreviewComponent', () => {
  let component: ContactreviewComponent;
  let fixture: ComponentFixture<ContactreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
