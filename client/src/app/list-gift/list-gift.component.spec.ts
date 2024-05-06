import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGiftComponent } from './list-gift.component';

describe('ListGiftComponent', () => {
  let component: ListGiftComponent;
  let fixture: ComponentFixture<ListGiftComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListGiftComponent]
    });
    fixture = TestBed.createComponent(ListGiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
