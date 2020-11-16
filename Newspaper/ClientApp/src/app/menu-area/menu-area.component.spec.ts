import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuAreaComponent } from './menu-area.component';

describe('MenuAreaComponent', () => {
  let component: MenuAreaComponent;
  let fixture: ComponentFixture<MenuAreaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuAreaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
