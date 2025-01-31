import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ExerciseModel } from '../../models/exerciseModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModules } from '../../material/material.module';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MaterialModules],
})
export class ExerciseListModalComponent {
  exercises: ExerciseModel[] = [];

  constructor(
    public dialogRef: MatDialogRef<ExerciseListModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { exercises: ExerciseModel[] }
  ) {
    this.exercises = data.exercises;
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
