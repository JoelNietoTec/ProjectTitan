export interface ParamMaster {
    ID?: number;
    CategoryID?: number;
    Name?: string;
    EnglishName?: string;
    FreeField?: string;
    IsRequired?: string;
    Weighting?: number;
    ParamCategoryID?: number;
    ParamCategory?: ParamCategory;
}

export interface ParamCategory {
    ID?: number;
    Name?: string;
    EnglishName?: string;
    Weighting?: number;
}

export interface ParamValue {
    ID?: number;
    ParamMasterID?: number;
    DisplayValue?: string;
    EnglishDisplayValue?: string;
    Score?: number;
    ParamMaster?: ParamMaster;
}
