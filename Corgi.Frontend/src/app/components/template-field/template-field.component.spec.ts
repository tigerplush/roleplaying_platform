import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateFieldComponent } from './template-field.component';

describe('TemplateFieldComponent', () => {
  let component: TemplateFieldComponent;
  let fixture: ComponentFixture<TemplateFieldComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemplateFieldComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
