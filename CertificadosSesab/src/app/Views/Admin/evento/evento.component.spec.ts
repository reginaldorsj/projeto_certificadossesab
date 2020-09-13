import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventoComponent } from './evento.component';

describe('EventosComponent', () => {
  let component: EventoComponent;
  let fixture: ComponentFixture<EventoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
