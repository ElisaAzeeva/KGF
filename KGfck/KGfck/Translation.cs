namespace KGfck
{
    public static class Translation
    {
        public static void MoveTransformPoint(ref double[] point, double moveX, double moveY, double moveZ)
        {
            var result = new double[4];
            double X = moveX;//ActualWidth / 2;
            double Y = moveY;//ActualWidth / 2;
            double Z = moveZ;//ActualHeight / 2;
            double[][] moveMatrix = new double[][] {
                new double[] {  1,  0,  0,  0 },
                new double[] {  0,  1,  0,  0 },
                new double[] {  0,  0,  1,  0 },
                new double[] {  X,  Y,  Z,  1 }
            };
            for (int i = 0; i < 4; i++)
            {
                result[i] = 0;
                result[i] += moveMatrix[0][i] * point[0]
                          + moveMatrix[1][i] * point[1]
                          + moveMatrix[2][i] * point[2]
                          + moveMatrix[3][i] * point[3];
            }
            point = result;
        }
    }
}
