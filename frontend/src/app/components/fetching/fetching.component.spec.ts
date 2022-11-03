import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchingComponent } from './fetching.component';

describe('FetchingComponent', () => {
  let component: FetchingComponent;
  let fixture: ComponentFixture<FetchingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FetchingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FetchingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
