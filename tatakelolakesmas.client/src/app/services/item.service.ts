// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

import { Injectable } from '@angular/core';
import { Observable, Subject, forkJoin } from 'rxjs';
import {catchError, mergeMap, tap } from 'rxjs/operators';

import { AccountEndpoint } from './account-endpoint.service';
import { AuthService } from './auth.service';
import { User } from '../models/user.model';
import { Role } from '../models/role.model';
import { Permission, PermissionValues } from '../models/permission.model';
import { UserEdit } from '../models/user-edit.model';
import {EndpointBase} from "./endpoint-base.service";
import {ConfigurationService} from "./configuration.service";
import { HttpClient } from '@angular/common/http';

export type RolesChangedOperation = 'add' | 'delete' | 'modify';
export interface RolesChangedEventArg { roles: Role[] | string[]; operation: RolesChangedOperation; }

@Injectable()
export class ItemService extends EndpointBase {
    private readonly baseUrl = '/api/item'

    constructor(private configurations: ConfigurationService, http: HttpClient, authService: AuthService) {
    super(http, authService);
    }
    
    getListItem(): Observable<any> {
    
        return this.http.get(`${this.baseUrl}/get-list`, this.requestHeaders).pipe(
            catchError(error => {
              return this.handleError(error, () => this.getListItem());
            }));
    }
    addItem(body: Record<string, any>): Observable<any> {

        return this.http.post(`${this.baseUrl}`, body , this.requestHeaders).pipe(
            catchError(error => {
                return this.handleError(error, () => this.addItem(body));
            }));
    }
}