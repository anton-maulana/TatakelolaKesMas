import {Region} from "./region.model";

export interface PublicHealthCenter {
    clinicCode: string;
    name: string;
    nameHeadCenter: string;
    nipHeadCenter: string;
    phone: string;
    status: string;
    region: Region;
    fkRegionId: string;
    id: number;
    createdDate: string;
    updatedDate: string;
    createdBy: string | null;
    updatedBy: string | null;
}