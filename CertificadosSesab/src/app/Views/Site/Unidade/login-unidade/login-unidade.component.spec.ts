import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginUnidadeComponent } from './login-unidade.component';

describe('LoginUnidadeComponent', () => {
  let component: LoginUnidadeComponent;
  let fixture: ComponentFixture<LoginUnidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginUnidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginUnidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
