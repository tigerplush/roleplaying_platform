import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TemplateService } from '../../services/template.service';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-create-template-dialog',
  imports: [ MatButtonModule, MatDialogModule, FormsModule, MatFormFieldModule, MatInputModule ],
  templateUrl: './create-template-dialog.component.html',
  styleUrl: './create-template-dialog.component.scss'
})
export class CreateTemplateDialogComponent {
  name: string = '';
  constructor(
    private router: Router
    , private templateService: TemplateService
    , private dialogRef: MatDialogRef<CreateTemplateDialogComponent>
  ) {

  }

  onConfirm() {
    this.templateService.createNewTemplate(this.name).subscribe({
      next: v => {
        this.router.navigate(['/templates/' + v.id]);
        this.dialogRef.close();
      },
      error: e => console.error(e)
    });
  }
}
