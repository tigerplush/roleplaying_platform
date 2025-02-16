import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-template-overview',
  imports: [ MatButtonModule, MatIconModule ],
  templateUrl: './template-overview.component.html',
  styleUrl: './template-overview.component.scss'
})
export class TemplateOverviewComponent {
  openNewTemplateDialog() {

  }
}
