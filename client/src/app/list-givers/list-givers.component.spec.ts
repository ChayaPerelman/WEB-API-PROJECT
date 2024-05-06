import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGiversComponent } from './list-givers.component';

describe('ListGiversComponent', () => {
  let component: ListGiversComponent;
  let fixture: ComponentFixture<ListGiversComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListGiversComponent]
    });
    fixture = TestBed.createComponent(ListGiversComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
