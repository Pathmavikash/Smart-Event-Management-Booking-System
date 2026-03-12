export interface LoginResponse {
    accessToken: string;
    expiresIn: number;
    role: string;
    userId: number;
    fullName: string;
}