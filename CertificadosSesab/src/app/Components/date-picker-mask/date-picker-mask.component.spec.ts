import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatePickerMaskComponent } from './date-picker-mask.component';

describe('DatePickerMaskComponent', () => {
  let component: DatePickerMaskComponent;
  let fixture: ComponentFixture<DatePickerMaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatePickerMaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatePickerMaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
