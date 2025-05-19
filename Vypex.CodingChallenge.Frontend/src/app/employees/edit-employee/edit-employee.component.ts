import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  inject,
} from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NZ_MODAL_DATA, NzModalRef } from 'ng-zorro-antd/modal';
import { NzTableModule } from 'ng-zorro-antd/table';
import { catchError, finalize, of, tap } from 'rxjs';
import { validateForm } from '../../common/validateForm';
import { EditLeaveComponent } from '../edit-leave/edit-leave.component';
import { EmployeeApiService } from '../services/employee-api.service';
import {
  EditEmployeeBindings,
  EditEmployeeResult,
} from './edit-employee.modal';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NzFormModule,
    NzButtonModule,
    NzInputModule,
    NzTableModule,
    EditLeaveComponent,
  ],
})
export class EditEmployeeComponent {
  private readonly modalRef = inject(
    NzModalRef<EditEmployeeComponent, EditEmployeeResult>
  );
  private readonly modalData = inject<EditEmployeeBindings>(NZ_MODAL_DATA);
  private readonly fb = inject(FormBuilder);
  private readonly cdr = inject(ChangeDetectorRef);
  private readonly employeeApiService = inject(EmployeeApiService);

  protected readonly name = this.modalData.name;
  protected readonly leaveDays = this.modalData.leaveDays;

  protected inEditMode = false;
  protected errorText = '';

  protected readonly form = this.fb.group({
    // 'name' will not be updated because it's out of scope.
    employeeId: this.fb.nonNullable.control(
      this.modalData.id,
      Validators.required
    ),
    startDate: this.fb.nonNullable.control('', Validators.required),
    endDate: this.fb.nonNullable.control('', Validators.required),
  });

  protected clearErrors(): void {
    this.errorText = '';
  }

  protected cancel(): void {
    this.inEditMode = false;
    this.errorText = '';
  }

  protected close(): void {
    this.inEditMode = false;
    this.errorText = '';
    this.modalRef.triggerCancel();
  }

  protected submit(): void {
    if (!validateForm(this.form)) {
      this.errorText = 'Start and end dates should be valid.';
      return;
    }

    this.errorText = '';

    const formValue = this.form.getRawValue();

    const date1 = new Date(formValue.startDate);
    const date2 = new Date(formValue.endDate);

    if (!date1.getTime() || !date2.getTime()) {
      return;
    }

    if (date1 >= date2) {
      this.errorText = 'Start date should be earlier than the end date.';
      return;
    }

    this.employeeApiService
      .createLeave(formValue.employeeId, formValue.startDate, formValue.endDate)
      .pipe(
        tap((result) => {
          this.leaveDays.push({
            id: result.toString(),
            startDate: formValue.startDate,
            endDate: formValue.endDate,
          });
          this.inEditMode = false;
          this.errorText = '';
        }),
        catchError((error) => {
          console.log(error);
          this.errorText = 'Network error';
          return of(null);
        }),
        finalize(() => {
          this.cdr.detectChanges();
        })
      )
      .subscribe();
  }

  protected addLeave() {
    this.inEditMode = true;
    this.errorText = '';
  }
}
