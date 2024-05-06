import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEdirGiversComponent } from './add-edir-givers.component';

describe('AddEdirGiversComponent', () => {
  let component: AddEdirGiversComponent;
  let fixture: ComponentFixture<AddEdirGiversComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEdirGiversComponent]
    });
    fixture = TestBed.createComponent(AddEdirGiversComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
