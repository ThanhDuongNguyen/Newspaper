import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MostViewNewsComponent } from './most-view-news.component';

describe('MostViewNewsComponent', () => {
  let component: MostViewNewsComponent;
  let fixture: ComponentFixture<MostViewNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostViewNewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostViewNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
