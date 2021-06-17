import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridHistoryComponent } from './grid-history.component';

describe('GridSearchComponent', () => {
  let component: GridHistoryComponent;
  let fixture: ComponentFixture<GridHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
