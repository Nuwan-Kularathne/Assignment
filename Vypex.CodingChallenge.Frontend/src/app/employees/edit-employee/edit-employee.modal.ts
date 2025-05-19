import { inject, Injectable } from '@angular/core';
import { NzModalRef, NzModalService } from 'ng-zorro-antd/modal';
import { LeaveDay } from '../models';
import { EditEmployeeComponent } from './edit-employee.component';

// TODO: Define modal result type
export type EditEmployeeResult = {};

// TODO: Define modal bindings
export interface EditEmployeeBindings {
  id: string;
  name: string;
  leaveDays: LeaveDay[];
}

@Injectable()
export class EditEmployeeModal {
  private readonly modalService = inject(NzModalService);

  public open(
    bindings?: EditEmployeeBindings
  ): NzModalRef<EditEmployeeComponent, EditEmployeeResult> {
    return this.modalService.create({
      nzTitle: 'Edit employee',
      nzContent: EditEmployeeComponent,
      nzData: bindings ?? {},
      nzMaskClosable: false,
      nzFooter: null,
    });
  }
}
