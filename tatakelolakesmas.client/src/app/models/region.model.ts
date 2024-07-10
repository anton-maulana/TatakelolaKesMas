export interface Region {
    id: string;
    name: string;
    type: number;
    parent: Region | null;
    fkParentId: string | null;
    createdDate: string;
    updatedDate: string;
    createdBy: string | null;
    updatedBy: string | null;
}

