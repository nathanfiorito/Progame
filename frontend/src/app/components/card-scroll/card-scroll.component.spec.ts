import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardScrollComponent } from './card-scroll.component';

describe('CardScrollComponent', () => {
  let component: CardScrollComponent;
  let fixture: ComponentFixture<CardScrollComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardScrollComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardScrollComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
