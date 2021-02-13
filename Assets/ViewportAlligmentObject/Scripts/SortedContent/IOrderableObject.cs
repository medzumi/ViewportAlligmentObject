

namespace ViewportAlligmentObject
{
    /// <summary>
    /// ��������� ����� ������� �������
    /// </summary>
    public interface IOrderableObject
    {
        /// <summary>
        /// �������� ������� ������� �������
        /// </summary>
        /// <returns></returns>
        int GetSiblingIndex();

        /// <summary>
        /// ���������� ������� �������
        /// </summary>
        /// <param name="value"></param>
        void SetSiblingIndex(int value);
    }
}