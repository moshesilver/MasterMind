namespace MasterMindSolver {
    public class Solver {
        private static Solver? solver;
        private Solver() {

        }
        public static Solver GetSolver() {
            solver ??= new Solver();
            return solver;
        }
    }
}
