class ComptePayant
{
    private double commission;
    private int nombreOperations;
    public double GetCommission()
    {
        return commission;
    }
    public void SetCommission(double commission)
    {
        this.commission = commission;
    }
    public int GetNombreOperations()
    {
        return nombreOperations;
    }
    public void SetNombreOperations(int nombreOperations)
    {
        this.nombreOperations = nombreOperations;
    }
    
}