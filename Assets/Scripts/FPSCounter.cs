using UnityEngine;
using UnityEngine.UI;

namespace Utilities {
    /// <summary>
    /// Отображает фпс
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class FPSCounter : MonoBehaviour {
        /// <summary>
        /// Время изменения FPS (чем больше значение, тем выше точность)
        /// </summary>
        const float fpsMeasurePeriod = 0.25f;
        /// <summary>
        /// Промежуточная переменная для расчета FPS
        /// </summary>
        private int m_FpsAccumulator = 0;
        /// <summary>
        /// Время следующего перерасчета количества кадров
        /// </summary>
        private float m_FpsNextPeriod = 0;

        private int m_CurrentFps;
        /// <summary>
        /// Паттерн текста отображения
        /// </summary>
        const string display = "{0} FPS";
        private Text m_Text;

        private void Start() {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();
        }

        private void Update() {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod) {
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);
            }
        }
    }
}